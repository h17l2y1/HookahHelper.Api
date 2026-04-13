using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HookahHelper.DAL.Entities.Interfaces;

namespace HookahHelper.DAL.Entities;

public class BaseEntity : IBaseEntity
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}