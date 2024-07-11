using TT.Mongo.Client;

namespace MongoCrud.API.Models.Domain
{
    public class Branch :BaseMongoEntity
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int BranchFee { get; set; }
    }
}
