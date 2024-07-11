namespace MongoCrud.API.Models.DTO
{
    public class StudentWithBranchDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        // public Branch Branch { get; set; }
        public int BranchId { get; set; }
        public AddBranchDto AddBranch { get; set; }
    }
}
