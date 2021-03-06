//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by NHibernate.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

						
// /$$      /$$           /$$   /$$     /$$ /$$                                                                            
//| $$$    /$$$          | $$  | $$    |__/| $$                                                                            
//| $$$$  /$$$$ /$$   /$$| $$ /$$$$$$   /$$| $$        /$$$$$$  /$$$$$$$   /$$$$$$  /$$   /$$  /$$$$$$   /$$$$$$   /$$$$$$ 
//| $$ $$/$$ $$| $$  | $$| $$|_  $$_/  | $$| $$       |____  $$| $$__  $$ /$$__  $$| $$  | $$ |____  $$ /$$__  $$ /$$__  $$
//| $$  $$$| $$| $$  | $$| $$  | $$    | $$| $$        /$$$$$$$| $$  \ $$| $$  \ $$| $$  | $$  /$$$$$$$| $$  \ $$| $$$$$$$$
//| $$\  $ | $$| $$  | $$| $$  | $$ /$$| $$| $$       /$$__  $$| $$  | $$| $$  | $$| $$  | $$ /$$__  $$| $$  | $$| $$_____/
//| $$ \/  | $$|  $$$$$$/| $$  |  $$$$/| $$| $$$$$$$$|  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$/|  $$$$$$$|  $$$$$$$|  $$$$$$$
//|__/     |__/ \______/ |__/   \___/  |__/|________/ \_______/|__/  |__/ \____  $$ \______/  \_______/ \____  $$ \_______/
//                                                                       /$$  \ $$                     /$$  \ $$          
//                                                                      |  $$$$$$/                    |  $$$$$$/          
//                                                                       \______/                      \______/          

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using NHibernate.UserTypes;
using Pangea.BaseStructures;
using Pangea.BasicValidators;
using System.Linq;


//using Pangea.Hibernate.UserTypes;

namespace NGU.Core
{

    public class CRequestStatus : ConstField    
    {
		private ConstField _ID = null;
		private ConstField _Code = null;
		private ConstField _Name = null;
		private ConstField _ActiveRecordFlag = null;
		private CLocalizedNames _ServerLangHub = null;


        public CRequestStatus()
        {
			_ID = new ConstField("ID");
			_Code = new ConstField("Code");
			_Name = new ConstField("Name");
			_ActiveRecordFlag = new ConstField("ActiveRecordFlag");
			_ServerLangHub = new CLocalizedNames("ServerLangHub");
        }
        

        public CRequestStatus(string parent)
            : base(parent)
        {
			_ID = new ConstField("ID", parent);
			_Code = new ConstField("Code", parent);
			_Name = new ConstField("Name", parent);
			_ActiveRecordFlag = new ConstField("ActiveRecordFlag", parent);
			_ServerLangHub = new CLocalizedNames("ServerLangHub", parent);
        }

        public CRequestStatus(string value, string parent)
            : base(value, parent)
        {
			_ID = new ConstField("ID", FormatPath(value, parent));
			_Code = new ConstField("Code", FormatPath(value, parent));
			_Name = new ConstField("Name", FormatPath(value, parent));
			_ActiveRecordFlag = new ConstField("ActiveRecordFlag", FormatPath(value, parent));
			_ServerLangHub = new CLocalizedNames("ServerLangHub", FormatPath(value, parent));
        }
        
		public ConstField ID
        {
            get
            {
                return this._ID;
            }
        }
		public ConstField Code
        {
            get
            {
                return this._Code;
            }
        }
		public ConstField Name
        {
            get
            {
                return this._Name;
            }
        }
		public ConstField ActiveRecordFlag
        {
            get
            {
                return this._ActiveRecordFlag;
            }
        }
		public CLocalizedNames ServerLangHub
        {
            get
            {
                return this._ServerLangHub;
            }
        }

    }


	/// <summary>
	/// POCO for RequestStatus. This class is autogenerated
	/// </summary>

	
	
	[Serializable]
	public partial  class RequestStatus :  MultiLanguage  	{
		#region Consts
		
		private static CRequestStatus props = null;

		
		public static CRequestStatus Props
        {
            get
            {
				if (props == null)
				{
					props = new CRequestStatus();
				}
                return props;
            }
        }

		#endregion
		
		#region Fields
		

		private Int32 iD;

		private String code;
	
		private String name;
	
		private bool? activeRecordFlag;
	
	
		private LocalizedNames serverLangHub;
	
		#endregion

		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the RequestStatus class
		/// </summary>
		public RequestStatus()
		{
		}
	
		#endregion
	
		#region Properties
		
		/// <summary>
		/// Gets or sets the ID for the current RequestStatus
		/// </summary>
		
	
	
[DataMember]
			public  virtual   Int32 ID
		{
			get 
			{ 
				return this.iD; 
			}
			set 
			{
				this.iD = value;
				NotifyPropertyChanged("ID");
			}
		}
/*
*/

		/// <summary>
		/// Gets or sets the Code for the current RequestStatus
		/// </summary>
		
	
	
[DataMember]
  		public  virtual  String Code
  		{
			get 
			{ 
				return this.code; 
			}
			set 
			{
				this.code = value;
				NotifyPropertyChanged("Code");
			}
		}
/*
*/

		/// <summary>
		/// Gets or sets the Name for the current RequestStatus
		/// </summary>
		
	
	
[DataMember]
  		public  virtual  String Name
  		{
			get 
			{ 
				return this.name; 
			}
			set 
			{
				this.name = value;
				NotifyPropertyChanged("Name");
			}
		}
/*
*/

		/// <summary>
		/// Gets or sets the ActiveRecordFlag for the current RequestStatus
		/// </summary>
		
	
	
[DataMember]
  		public virtual bool? ActiveRecordFlag
  		{
			get 
			{ 
				return this.activeRecordFlag; 
			}
			set 
			{
				this.activeRecordFlag = value;
				NotifyPropertyChanged("ActiveRecordFlag");
			}
		}
/*
*/

		/// <summary>
		/// Gets or sets the ServerLangHub for the current RequestStatus
		/// </summary>
		
	
	
[DataMember]
  		public  virtual  LocalizedNames ServerLangHub
  		{
			get 
			{ 
				return this.serverLangHub; 
			}
			set 
			{
				this.serverLangHub = value;
				NotifyPropertyChanged("ServerLangHub");
			}
		}
/*
*/



		#endregion
		
		#region Equals override
			
		public override bool Equals(object obj)
		{
			if(obj == null)
				return false;
				
            var pi = obj.GetType().GetProperty("ID");
            
            if(pi == null)
            {
				return false;
            }
            
            var val = pi.GetValue(obj, null);
            if(val != null)
            {
				return val.Equals(ID);
			}
			else
			{
				#pragma warning disable CS0472 // Generated
				if(ID == null)
				#pragma warning restore CS0472 // Generated
					return true;
				else
					return false;
			}
		}	

		public override int GetHashCode()
        {
            return base.GetHashCode();
        }
		
	#endregion

	}	
}