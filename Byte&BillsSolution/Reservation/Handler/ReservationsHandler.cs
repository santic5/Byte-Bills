using Byte_BillsSolution.Reservation.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_BillsSolution.Reservation.Handler
{
    public class ReservationsHandler
    {
        private HashFile file = new();

        public ReservationsHandler() { }
        public bool Create(int prmId, string prmDate)
        {
            var attDate = DateTime.Parse(prmDate);
            int attHash = prmId.GetHashCode() + attDate.GetHashCode();
            file.Write(attHash);
            return true;
        }

        public bool Check(int prmId, string prmDate)
        {
            var attDate = DateTime.Parse(prmDate);
            int attHash = prmId.GetHashCode() + attDate.GetHashCode();
            return file.Search(attHash);
        }

        public bool Delete(int prmId, string prmDate)
        {
            var attDate = DateTime.Parse(prmDate);
            int attHash = prmId.GetHashCode() + attDate.GetHashCode();
            return file.Delete(attHash);
        }

        public string GetReservations()
        {
            return this.file.Read();
        }

        public int GetLength()
        {
            return this.file.GetLength();
        }

        public void Purge()
        {
            file.Purge();
        }

    }
}
