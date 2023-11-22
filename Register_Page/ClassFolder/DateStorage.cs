using Register_Page.DataFolder;
using System.Collections.Generic;
using System.Linq;

namespace Register_Page.ClassFolder
{
    //class DateStorage
    //{
    //    private List<Client> deletedClients = new List<Client>();


    //    public void ArchiveClient(Client client)
    //    {
    //        deletedClients.Add(client);
    //    }

    //    public void RestoreClient(int clientId)
    //    {
    //        var restoredClient = deletedClients.FirstOrDefault(c => c.ClientId == clientId);

    //        if (restoredClient != null)
    //        {

    //            DBEntities.GetContext().Client.Add(restoredClient);

    //            // Удалите клиента из коллекции удаленных данных
    //            deletedClients.Remove(restoredClient);
    //        }
    //    }

    //    public List<Client> GetDeletedClients()
    //    {
    //        return deletedClients;
    //    }
    //}
}
