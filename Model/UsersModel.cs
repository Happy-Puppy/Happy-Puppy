/**  Class Info。
* UsersModel.cs
*
* 功 能： N/A
* 类 名： UsersModel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  9/24/2020 11:27:54 PM   N/A    初版
*
* Copyright (c) 2020. All rights reserved.
* ───────────────────────────────────
*/
using System;
namespace DogApi.Model
{
	/// <summary>
	/// UsersModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UsersModel
	{
		public UsersModel()
		{}
		#region Model
		private string _username;
		private string _password;
		private double? _lat;
		private double? _lng;
		private double? _alt;
		private string _tel;
		private int? _age;
		/// <summary>
		/// 
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string passWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? lat
		{
			set{ _lat=value;}
			get{return _lat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? lng
		{
			set{ _lng=value;}
			get{return _lng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double? alt
		{
			set{ _alt=value;}
			get{return _alt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? age
		{
			set{ _age=value;}
			get{return _age;}
		}
		#endregion Model

	}
}

