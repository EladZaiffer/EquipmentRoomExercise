internal class EquipmentUnavailableException : Exception
{
    public int RequestedAmount { get; set; }
    public int MissingAmount { get; set; }

    public EquipmentUnavailableException(string message, int requestedAmount, int missingAmount)
        : base(message)
    {
        RequestedAmount = requestedAmount;
        MissingAmount = missingAmount;
    }
}