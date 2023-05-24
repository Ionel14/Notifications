using MongoDB.Driver;
using NewsAPI.Model;
using NewsAPI.Settings;

namespace NewsAPI.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        private readonly IMongoCollection<Announcement> _announcements;

        public AnnouncementCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _announcements = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
        }


        //public bool Create(Announcement model)
        //{
        //    _announcements.Add(model);
        //    return true;
        //}

        public async Task<bool> Create(Announcement announcement)
        {
            if (announcement.Id == Guid.Empty)
            {
                announcement.Id = Guid.NewGuid();
            }

            await _announcements.InsertOneAsync(announcement);
            return true;
        }

        //public bool Delete(Guid id)
        //{
        //    Announcement? announcementToDelete = _announcements.FirstOrDefault(item => item.Id == id);
        //    if (announcementToDelete == null)
        //    {
        //       return false;
        //    }
        //    _announcements.Remove(announcementToDelete);
        //    return true;
        //}

        public async Task<bool> Delete(Guid id)
        {
            var result = await _announcements.DeleteOneAsync(announcement => announcement.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        //public Announcement Get(Guid id)
        //{
        //    return _announcements.FirstOrDefault(announcement => announcement.Id == id);
        //}

        public async Task<Announcement> Get(Guid id)
        {
            return (await _announcements.FindAsync(announcement => announcement.Id == id)).FirstOrDefault();
        }


        public async Task<List<Announcement>> GetAll()
        {
            var result = await _announcements.FindAsync(announcement => true);
            return result.ToList();
        }


        //public List<Announcement> GetAnnouncementsByCategoryId(string categoryId)
        //{
        //    return _announcements.Where(announcement => announcement.CategoryId == categoryId).ToList();
        //}

        public async Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId)
        {
            return (await _announcements.FindAsync(announcement => announcement.CategoryId == categoryId)).ToList();
        }


        //public bool Update(Guid id, Announcement model)
        //{
        //    Announcement? announcementToUpdate = _announcements.FirstOrDefault(item => item.Id == id);
        //    if (announcementToUpdate == null)
        //    {
        //        return false;
        //    }

        //    model.Id = id;
        //    _announcements.Remove(announcementToUpdate);
        //    _announcements.Add(model);
        //    return true;
        //}

        public async Task<bool> Update(Guid id, Announcement announcement)
        {
            announcement.Id = id;
            var result = await _announcements.ReplaceOneAsync(announcement => announcement.Id == id, announcement);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _announcements.InsertOneAsync(announcement);
                return false;
            }

            return true;
        }

    }
}
