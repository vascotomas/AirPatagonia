using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class DispatcherModel
{
    public int IdDispatcher { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime BirthDate { get; set; }
    public DocumentType DocumentType { get; set; }
    public string NoDocument { get; set; }
}

public class DocumentType
{
    public int IdDocumentType { get; set; }
    public string Name { get; set; }
}