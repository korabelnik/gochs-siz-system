using System.ComponentModel.DataAnnotations;

namespace GochsSiz.Models
{
    public class DisposalAct
    {
        public int Id { get; set; }

        [Display(Name = "Номер акта")]
        [Required]
        public string ActNumber { get; set; } = "";

        [Display(Name = "Дата утилизации")]
        [DataType(DataType.Date)]
        public DateTime DisposalDate { get; set; } = DateTime.Now;

        [Display(Name = "Способ утилизации")]
        public string DisposalMethod { get; set; } = ""; // Сжигание, Захоронение, Передача

        [Display(Name = "Класс отходов")]
        public string WasteClass { get; set; } = ""; // I-IV класс

        [Display(Name = "Контрагент")]
        public string Contractor { get; set; } = "";

        [Display(Name = "Примечание")]
        public string Notes { get; set; } = "";

        // Связь с СИЗ
        public int SizItemId { get; set; }
        public SizItem? SizItem { get; set; }
    }
}