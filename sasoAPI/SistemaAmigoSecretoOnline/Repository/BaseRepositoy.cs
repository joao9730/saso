using SistemaAmigoSecretoOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaAmigoSecretoOnline.Repository
{
    public class BaseRepositoy
    {
        private EntityDataModel _DataModel;
        
        public EntityDataModel DataModel
        {
            get
            {
                if (_DataModel == null)
                {
                    _DataModel = new EntityDataModel();
                }
                return _DataModel;
                
            }
                    
            }
        }

    }
