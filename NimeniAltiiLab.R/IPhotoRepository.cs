using NimeniAltii.Models.Photo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NimeniAltiiLab.Repository
{
   public interface IPhotoRepository
    {
        public Task<Photo> InsertAsync(PhotoCreate photoCreate, int ApplicationUserId);

        public Task<Photo> GetAsync(int photoId);

        public Task<List<Photo>> GetAllByUserIdAsync(int ApplicationUserId);

        public Task<int> DeleteAsync(int photoId);


    }
}
