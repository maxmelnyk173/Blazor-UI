using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.web.Data
{
    public enum TransactionType
    {
        Income,
        Expense
    }

    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(TransactionType))]
        public TransactionType TransactionType { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10. 2)")]
        [Range(0.01, 100000, ErrorMessage = "Payment amount need to be higher than 0")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date format is MM/dd/yyyy")]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;

        public string Description { get; set; }

        public Category Category { get; set; }
    }
}
