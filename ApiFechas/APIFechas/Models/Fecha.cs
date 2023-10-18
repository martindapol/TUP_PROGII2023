namespace APIFechas.Models
{
    public class Fecha
    {
        public Fecha()
        {
            DateTime f = DateTime.Now;
            Numero = f.Day;
            Mes = f.Month;
            Anio = f.Year;
            DiaSemana = f.DayOfWeek.ToString();

        }

        public int Numero { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public String DiaSemana { get; set; }

    }
}
