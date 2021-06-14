namespace ClientsAgregator_BLL.CustomModels.OrderModels
{
    public class ClientsFullNameModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ClientsFullNameModel model &&
                   Id == model.Id &&
                   FullName == model.FullName;
        }
    }
}
