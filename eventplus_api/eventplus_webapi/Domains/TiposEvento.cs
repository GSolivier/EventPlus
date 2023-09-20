using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventplus_webapi.Domains
{
    /// <summary>
    /// Domain que representa a entidade TiposEvento
    /// </summary>
    [Table(nameof(TiposEvento))]
    public class TiposEvento
    {
        [Key]
        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Título do evento obrigatório")]
        public string? Titulo { get; set; }


    }
}
