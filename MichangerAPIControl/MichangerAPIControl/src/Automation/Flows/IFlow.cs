using System;
using System.Drawing;
using System.Threading.Tasks;
using MichangerAPIControl.ApiClients;

namespace MichangerAPIControl.Automation.Flows
{
    /// <summary>
    /// Defines a standard contract for all automation flows.
    /// Any class implementing this interface will be automatically discovered
    /// by the FlowRegistry and presented as a runnable flow in the UI.
    ///
    /// --- HOW TO CREATE A CUSTOM FLOW ---
    /// 1. Create a new .cs file anywhere in the project.
    /// 2. Implement this interface.
    /// 3. That's it — the flow will appear automatically in the UI.
    ///
    /// Example:
    /// <code>
    /// public class MyCustomFlow : IFlow
    /// {
    ///     public string Name => "My Custom Flow";
    ///
    ///     public async Task ExecuteAsync(BaseApiClient apiClient, string serial,
    ///         Action&lt;string&gt; log, Action&lt;string, Color&gt; updateStatus)
    ///     {
    ///         log($"[{Name}] Starting on device: {serial}");
    ///         // ... your logic here ...
    ///         updateStatus("Done", Color.LightGreen);
    ///     }
    /// }
    /// </code>
    /// </summary>
    public interface IFlow
    {
        /// <summary>
        /// Display name shown in the UI button.
        /// Ten hien thi tren giao dien.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Executes the automation flow on a single device.
        /// Thuc thi luong tu dong tren mot thiet bi.
        /// </summary>
        /// <param name="apiClient">Active API client (Michanger or OneChanger)</param>
        /// <param name="serial">ADB device serial number</param>
        /// <param name="log">Callback to write to the global log console</param>
        /// <param name="updateStatus">Callback to update per-device status label and color</param>
        Task ExecuteAsync(
            BaseApiClient apiClient,
            string serial,
            Action<string> log,
            Action<string, Color> updateStatus);
    }
}
