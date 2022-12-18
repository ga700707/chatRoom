using System;
using System.Collections.Generic;
using System.Linq;

using ctest_model;
using ctest_model.Entities;
using ctest_model.Interface;
using ctest_service.Interface;
using ctest_viewmodel;
using Microsoft.EntityFrameworkCore;

namespace ctest_service
{
	public class ChatRoomS : IChatRoomS
	{

		private readonly IRepository<ChatLog> _examroom = new Repository<ChatLog>();


		public IEnumerable<ChatLog> GetAll()
		{
			var result = _examroom.GetAll();
			return result;
			
		}

        public void Create(ChatLog param)
        {
			_examroom.Create(param);
        }

    }
}
