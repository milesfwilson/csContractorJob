namespace csContractorJob.Models
{
  public class Contractor
  {

    public string Name { get; set; }

    public int Id { get; set; }

    public int Rate { get; set; }

    public string CreatorId { get; set; }

  }

  public class ContractorJobViewModel : Contractor
  {
    public int ContractorJobId { get; set; }
  }
}