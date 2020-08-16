using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public partial class DogId
    {
        public long Value { get; set; }
    }
    public partial class DogModel
    {
        public DogModel() { }
        public DogModel(DogModel clone)
        {
            DogId = clone?.DogId ?? new DogId();
            Name = clone?.Name;
            AdoptedDate = clone?.AdoptedDate;
            Birthdate = clone?.Birthdate;
            Gender = clone.Gender;
            Created = clone?.Created ?? DateTime.UtcNow;
            Modified = clone?.Modified ?? DateTime.UtcNow;
            Deleted = clone?.Deleted;
        }
        [Required]
        public DogId DogId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public DateTime? AdoptedDate { get; set; }
        public DateTime? Birthdate { get; set; }
        [Required]
        public DateTime? Created { get; set; }
        [Required]
        public DateTime? Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }


    public partial class DocumentId
    {
        public long Value { get; set; }
    }
    public partial class DocumentModel
    {
        public DocumentModel()
        {
            Tags = new List<DocumentTagModel>();
        }
        [Required]
        public DocumentId DocumentId { get; set; }
        [Required]
        public string FileName { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public int ByteSize { get; set; }
        [Required]
        public FolderModel Folder { get; set; }
        [Required]
        public Guid DocumentKey { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime LastViewed { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
        public IList<DocumentTagModel> Tags { get; set; }
    }
    public partial class DocumentTagId
    {
        public long Value { get; set; }
    }
    public partial class DocumentTagModel
    {
        [Required]
        public DocumentTagId DocumentTagId { get; set; }
        [Required]
        public string TagName { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
    public partial class FolderId
    {
        public long Value { get; set; }
    }
    public partial class FolderModel
    {
        public FolderId FolderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastViewed { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }


    public partial class HealthId
    {
        public long Value { get; set; }
    }
    public partial class HealthModel
    {
        public HealthId HealthId { get; set; }
        public DogModel Dog { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Length { get; set; }
        public decimal? Waist { get; set; }
        public decimal? TailLength { get; set; }
        public decimal? MouthCircumference { get; set; }
        public decimal? NoseEyeLength { get; set; }
        public bool FromVet { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }

    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
        Other = 3
    }
}