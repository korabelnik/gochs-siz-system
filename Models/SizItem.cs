using System.ComponentModel.DataAnnotations;

namespace GochsSiz.Models
{
    public class SizItem
    {
        public int Id { get; set; }

        [Display(Name = "Тип СИЗ")]
        [Required(ErrorMessage = "Укажите тип")]
        public string ItemType { get; set; } = ""; // Противогаз, Аптечка, Костюм Л-1

        [Display(Name = "Наименование")]
        [Required]
        public string Name { get; set; } = "";

        [Display(Name = "Номер партии")]
        public string BatchNumber { get; set; } = "";

        [Display(Name = "Завод-изготовитель")]
        public string Manufacturer { get; set; } = "";

        [Display(Name = "Дата изготовления")]
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; } = DateTime.Now;

        [Display(Name = "Срок годности до")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; } = DateTime.Now.AddYears(5);

        [Display(Name = "Размер")]
        public string Size { get; set; } = "";

        [Display(Name = "Место хранения")]
        public string StorageLocation { get; set; } = "";

        [Display(Name = "Состояние")]
        public string Status { get; set; } = "На складе"; // На складе / Выдано / Списано

        [Display(Name = "Выдано сотруднику")]
        public string AssignedTo { get; set; } = "";

        [Display(Name = "Инвентарный номер")]
        public string InventoryNumber { get; set; } = "";

        // Связь с утилизацией
        public List<DisposalAct> DisposalActs { get; set; } = new();
    }
}