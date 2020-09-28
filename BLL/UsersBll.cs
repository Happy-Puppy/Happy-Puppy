/**  Class Info。
* UsersBll.cs
*
* 功 能： N/A
* 类 名： UsersBll
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  9/24/2020 11:27:54 PM   N/A    初版
*
* Copyright (c) 2020. All rights reserved.
* ───────────────────────────────────
*/
using System;
using System.Data;
using System.Collections.Generic;

using DogApi.Model;
namespace DogApi.BLL
{
	/// <summary>
	/// UsersBll
	/// </summary>
	public partial class UsersBll
	{
		private readonly DogApi.DAL.UsersDao dal=new DogApi.DAL.UsersDao();
		public UsersBll()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string userName)
		{
			return dal.Exists(userName);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DogApi.Model.UsersModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DogApi.Model.UsersModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string userName)
		{
			
			return dal.Delete(userName);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string userNamelist )
		{
			return dal.DeleteList(userNamelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DogApi.Model.UsersModel GetModel(string userName)
		{
			
			return dal.GetModel(userName);
		}

		 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DogApi.Model.UsersModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DogApi.Model.UsersModel> DataTableToList(DataTable dt)
		{
			List<DogApi.Model.UsersModel> modelList = new List<DogApi.Model.UsersModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DogApi.Model.UsersModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

