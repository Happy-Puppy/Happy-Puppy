/**  Class Info。
* ActivityModel.cs
*
* 功 能： N/A
* 类 名： ActivityModel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  9/16/2020 9:17:37 PM   N/A    初版
*
* Copyright (c) 2020. All rights reserved.
* ───────────────────────────────────
*/
using System;
namespace DogApi.Model
{
	/// <summary>
	/// ActivityModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ActivityModel
	{
		public ActivityModel()
		{}
		#region Model
		private int _actid;
		private string _name;
		private string _note;
		private double? _lat;
		private double? _lng;
		private double? _alt;
		private string _username;
		/// <summary>
		/// 
		/// </summary>
		public int actid
		{
			set{ _actid=value;}
			get{return _actid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string note
		{
			set{ _note=value;}
			get{return _note;}
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
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		#endregion Model

	}
}

