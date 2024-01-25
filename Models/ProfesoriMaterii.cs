namespace examen.Models
{
    public class ProfesoriMaterii
    {
        public int ProfesorId { get; set; }
        public int MaterieId { get; set; }

        public Materie? Materie { get; set; }
        public Profesor? Profesor { get; set; }
    }
}
