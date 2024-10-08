﻿using AutoMapper;
using DAL.Models;
using DataTransferObjects;

namespace DAL
{
    public class RepositoryDal : IDAL.IRepositoryDAL
    {
        private readonly VersionMmanagementSystemContext dbContext;
        private readonly IMapper mapper;

        public RepositoryDal(VersionMmanagementSystemContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public bool AddNew(RepositoryDTO repository)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RepositoryDTO, Repository>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Repository>(repository);

                dbContext.Repositories.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(RepositoryDTO repositoryDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RepositoryDTO, Repository>();
                });

                var localMapper = config.CreateMapper();
                var repositoryEntity = localMapper.Map<Repository>(repositoryDto);

                var repositoryToDelete = dbContext.Repositories.Find(repositoryEntity.RepositoryId);
                if (repositoryToDelete != null)
                {
                    dbContext.Repositories.Remove(repositoryToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
                return false; // המשתמש לא נמצא
            }
            catch (Exception ex)
            {
                // טיפול בלוג או פעולות אחרות כדי להבין את הבעיה
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public RepositoryDTO Get(int id)
        {
            try
            {
                var repository = dbContext.Repositories.Find(id);
                if (repository == null) return null;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Repository, RepositoryDTO>();
                });

                var localMapper = config.CreateMapper();
                return localMapper.Map<RepositoryDTO>(repository);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<RepositoryDTO> GetAll()
        {
            try
            {
                var repositorys = dbContext.Repositories.ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Repository, RepositoryDTO>();
                });

                var localMapper = config.CreateMapper();
                return repositorys.Select(repository => localMapper.Map<RepositoryDTO>(repositorys)).ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(RepositoryDTO repository)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RepositoryDTO, Repository>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Repository>(repository);

                dbContext.Repositories.Update(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
