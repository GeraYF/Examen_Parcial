using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcialApp.Models
{
    public class ConversionHistorial
{
    public int Id { get; set; }
    public decimal TasaCambio { get; set; }
    public DateTime Fecha { get; set; }
    public string? MonedaOrigen { get; set; }
    public string? MonedaDestino { get; set; }
}
}