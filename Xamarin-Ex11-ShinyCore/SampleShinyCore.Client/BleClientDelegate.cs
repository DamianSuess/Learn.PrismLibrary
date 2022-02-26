using System;
using System.Collections.Generic;
using System.Text;
using Shiny;
using Shiny.BluetoothLE;

namespace XamarinHelloBle.Client
{
  public class BleClientDelegate : BleDelegate
  {
    readonly SampleSqliteConnection conn;
    readonly INotificationManager notifications;


    public BleClientDelegate(SampleSqliteConnection conn, INotificationManager notificationManager)
    {
      this.conn = conn;
      this.notifications = notificationManager;
    }


    public override async Task OnAdapterStateChanged(AccessState state)
    {
      if (state == AccessState.Disabled)
        await this.notifications.Send("BLE State", "Turn on Bluetooth already");
    }


    public override async Task OnConnected(IPeripheral peripheral)
    {
      //await this.services.Connection.InsertAsync(new BleEvent
      //{
      //    Description = $"Peripheral '{peripheral.Name}' Connected",
      //    Timestamp = DateTime.Now
      //});
      //await this.services.Notifications.Send(
      //    this.GetType(),
      //    true,
      //    "BluetoothLE Device Connected",
      //    $"{peripheral.Name} has connected"
      //);
    }
  }
}
