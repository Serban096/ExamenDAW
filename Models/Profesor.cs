namespace examen.Models
{
    public enum TipProfesor
    {
        Standard,
        
    }
    public class Profesor
    {
        public int ProfesorId { get; set; }
        public string? Nume { get; set; }
        public int Varsta { get; set; }

        public TipProfesor Tip {get; set;}

        public ICollection<ProfesoriMaterii>? ProfesoriMaterii { get; set; }
    }
}
