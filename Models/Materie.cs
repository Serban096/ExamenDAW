namespace examen.Models
{
    public class Materie
    {
        public int MaterieId { get; set; }
        public string? Nume { get; set; }
        public int Credite { get; set; }

        public ICollection<ProfesoriMaterii>? ProfesoriMaterii { get; set; }
    }
}
