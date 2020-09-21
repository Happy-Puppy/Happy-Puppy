/**  Class Info。
* DogTypeDao.cs
*
* 功 能： N/A
* 类 名： DogTypeDao
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
using System.Text;
using System.Data.SQLite;
using DogApi.Tool;//Please add references
namespace DogApi.DAL
{
	/// <summary>
	/// 数据访问类:DogTypeDao
	/// </summary>
	public partial class DogTypeDao
	{
		public DogTypeDao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("typeid", "dogType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int typeid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dogType");
			strSql.Append(" where typeid=@typeid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@typeid", DbType.Int32,4)			};
			parameters[0].Value = typeid;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DogApi.Model.DogTypeModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dogType(");
			strSql.Append("typeid,name)");
			strSql.Append(" values (");
			strSql.Append("@typeid,@name)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@typeid", DbType.Int32,4),
					new SQLiteParameter("@name", DbType.String,50)};
			parameters[0].Value = model.typeid;
			parameters[1].Value = model.name;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DogApi.Model.DogTypeModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dogType set ");
			strSql.Append("name=@name");
			strSql.Append(" where typeid=@typeid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@name", DbType.String,50),
					new SQLiteParameter("@typeid", DbType.Int32,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.typeid;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int typeid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dogType ");
			strSql.Append(" where typeid=@typeid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@typeid", DbType.Int32,4)			};
			parameters[0].Value = typeid;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string typeidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dogType ");
			strSql.Append(" where typeid in ("+typeidlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DogApi.Model.DogTypeModel GetModel(int typeid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select typeid,name from dogType ");
			strSql.Append(" where typeid=@typeid ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@typeid", DbType.Int32,4)			};
			parameters[0].Value = typeid;

			DogApi.Model.DogTypeModel model=new DogApi.Model.DogTypeModel();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DogApi.Model.DogTypeModel DataRowToModel(DataRow row)
		{
			DogApi.Model.DogTypeModel model=new DogApi.Model.DogTypeModel();
			if (row != null)
			{
				if(row["typeid"]!=null && row["typeid"].ToString()!="")
				{
					model.typeid=int.Parse(row["typeid"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select typeid,name ");
			strSql.Append(" FROM dogType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM dogType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQLite.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.typeid desc");
			}
			strSql.Append(")AS Row, T.*  from dogType T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "dogType";
			parameters[1].Value = "typeid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

