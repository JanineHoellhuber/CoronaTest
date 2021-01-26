using System.ComponentModel.DataAnnotations;
using CoronaTest.Core.Contracts;

namespace CoronaTest.Core.Entities
{

  public class EntityObject : IEntityObject
        {
            #region IEnityObject 

            [Key]
            public int Id { get; set; }

            [Timestamp]
            public byte[] RowVersion
            {
                get;
                set;
            }

            #endregion
        }
}
