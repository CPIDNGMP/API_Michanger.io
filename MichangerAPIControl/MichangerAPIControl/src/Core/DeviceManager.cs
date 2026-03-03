using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MichangerAPIControl.Controls;
using MichangerAPIControl.Models;

namespace MichangerAPIControl.Core
{
    /// <summary>
    /// Manages the state of connected devices and updates the UI.
    /// Quản lý trạng thái hộp các thiết bị được kết nối.
    /// </summary>
    public class DeviceManager
    {
        private readonly FlowLayoutPanel _uiPanel;
        private readonly List<DeviceControlItem> _uiCollection;
        private readonly Action<DeviceControlItem> _onDeviceAdded;

        public DeviceManager(FlowLayoutPanel uiPanel, List<DeviceControlItem> uiCollection, Action<DeviceControlItem> onDeviceAdded)
        {
            _uiPanel = uiPanel;
            _uiCollection = uiCollection;
            _onDeviceAdded = onDeviceAdded;
        }

        /// <summary>
        /// Làm mới danh sách thiết bị một cách bất đồng bộ.
        /// </summary>
        public async Task RefreshDevicesAsync()
        {
            var activeSerials = await AdbClient.GetDevicesAsync();

            _uiPanel.Invoke(new System.Action(() =>
            {
                // Xoá các thiết bị bị ngắt kết nối
                var toRemove = _uiCollection.Where(d => !activeSerials.Contains(d.GetConfig().SerialNumber)).ToList();
                foreach (var item in toRemove)
                {
                    _uiCollection.Remove(item);
                    _uiPanel.Controls.Remove(item);
                    item.Dispose();
                }

                // Thêm hoặc cập nhật trạng thái
                foreach (var serial in activeSerials)
                {
                    var existing = _uiCollection.FirstOrDefault(d => d.GetConfig().SerialNumber == serial);
                    if (existing == null)
                    {
                        var deviceItem = new DeviceControlItem();
                        var config = DeviceConfigManager.GetConfig(serial);
                        deviceItem.SetDevice(config, "Connected");
                        _onDeviceAdded?.Invoke(deviceItem);
                        
                        _uiPanel.Controls.Add(deviceItem);
                        _uiCollection.Add(deviceItem);
                    }
                    else
                    {
                        existing.SetDevice(existing.GetConfig(), "Connected");
                    }
                }
            }));
        }
    }
}
