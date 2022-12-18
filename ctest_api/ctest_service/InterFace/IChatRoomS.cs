using System.Collections.Generic;
using ctest_model.Entities;
using ctest_viewmodel;

namespace ctest_service.Interface
{
    public interface IChatRoomS
	{
		IEnumerable<ChatLog> GetAll();
		void Create(ChatLog param);
	}
}
