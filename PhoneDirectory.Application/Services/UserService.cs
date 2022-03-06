﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Application.Dtos;
using PhoneDirectory.Application.Dtos.CreateDtos;
using PhoneDirectory.Application.Dtos.GetDtos;
using PhoneDirectory.Application.Dtos.UpdateDtos;
using PhoneDirectory.Application.Interfaces;
using PhoneDirectory.Domain.CustomExceptions;
using PhoneDirectory.Domain.Entities;
using PhoneDirectory.Infrastructure.Database;

namespace PhoneDirectory.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public UserService(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        public async Task<ApplicationUserDto> GetById(int userId)
        {
            var user = await _dbContext.Users
                .Include(x => x.Division)
                .Include(x => x.PhoneNumbers)
                .FirstOrDefaultAsync(x => x.Id == userId);

            return _mapper.Map<ApplicationUserDto>(user);
        }

        public async Task<List<ApplicationUserDto>> SearchByName(string namePattern)
        {
            var users = await _dbContext.Users
                .Where(x => x.Name.ToLower().Contains(namePattern.ToLower()))
                .Include(x => x.Division)
                .Include(x => x.PhoneNumbers)
                .ToListAsync();

            return _mapper.Map<List<ApplicationUserDto>>(users);
        }

        public async Task Create(CreateUserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateUserDto userDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userDto.Id);

            if (user is null)
            {
                throw new UserNotFoundException(userDto.Id);
            }
            
            user.Name = userDto.Name;
            user.IsChief = user.IsChief;
            user.DivisionId = user.DivisionId;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SetChief(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            
            user.IsChief = true;

            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}