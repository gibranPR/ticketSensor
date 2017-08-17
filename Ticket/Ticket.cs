using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket
{
    class Ticket
    {
        public int id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public DateTime fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }
        public String horaLlegadaMin
        {
            get { return this.horaLlegadaMin; }
            set { this.horaLlegadaMin = value; }
        }
        public String horaLlegadaMax
        {
            get { return this.horaLlegadaMax; }
            set { this.horaLlegadaMax = value; }
        }
        public int alta
        {
            get { return this.alta; }
            set { this.alta = value; }
        }
        public int asignado
        {
            get { return this.asignado; }
            set { this.asignado = value; }
        }
        public string cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }
        public string falla
        {
            get { return this.falla; }
            set { this.falla = value; }
        }
        public string causa
        {
            get { return this.causa; }
            set { this.causa = value; }
        }
        public string observaciones
        {
            get { return this.observaciones; }
            set { this.observaciones = value; }
        }
        public int estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        public int tipoTicket
        {
            get { return this.tipoTicket; }
            set { this.tipoTicket = value; }
        }
    }
}
