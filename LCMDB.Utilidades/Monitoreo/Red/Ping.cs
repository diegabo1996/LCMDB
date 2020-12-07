using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LCMDB.Utilidades.Monitoreo.Red
{
    public class TestPing
    {
        private int timeout = 100;
        public async Task<bool> PingAsync(string ip)
        {
            Ping ping = new Ping();
            var reply = await ping.SendPingAsync(ip, timeout);
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
