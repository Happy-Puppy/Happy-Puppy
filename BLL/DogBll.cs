﻿/**  Class Info。
* DogBll.cs
*
* 功 能： N/A
* 类 名： DogBll
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  9/16/2020 9:17:38 PM   N/A    初版
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
	/// DogBll
	/// </summary>
	public partial class DogBll
	{
		private readonly DogApi.DAL.DogDao dal=new DogApi.DAL.DogDao();
		public DogBll()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int dogid)
		{
			return dal.Exists(dogid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DogApi.Model.DogModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DogApi.Model.DogModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int dogid)
		{
			
			return dal.Delete(dogid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string dogidlist )
		{
			return dal.DeleteList(dogidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DogApi.Model.DogModel GetModel(int dogid)
		{
			
			return dal.GetModel(dogid);
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
		public List<DogApi.Model.DogModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DogApi.Model.DogModel> DataTableToList(DataTable dt)
		{
			List<DogApi.Model.DogModel> modelList = new List<DogApi.Model.DogModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DogApi.Model.DogModel model;
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

