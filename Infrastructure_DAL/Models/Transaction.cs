﻿using System;
using System.Collections.Generic;

namespace Infrastructure_DAL.Models;

public partial class Transaction
{
    public int TransactionID { get; set; }

    public int TransactionTypeID { get; set; }

    public int ClientID { get; set; }

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }

    public byte TransactionStatus { get; set; }

    public string? Notes { get; set; }

    public int CreatedByUserID { get; set; }

    public int? TransferID { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual TransactionType TransactionType { get; set; } = null!;

    public virtual TransferHistory? Transfer { get; set; }

    public Transaction() { }
    public Transaction(int transactionID, int transactionTypeID, int clientID, decimal amount
        , DateTime transactionDate, byte transactionStatus, string? notes
        , int createdByUserID, int? transferID, DateTime createdAt, DateTime updatedAt)
    {
        TransactionID = transactionID;
        TransactionTypeID = transactionTypeID;
        ClientID = clientID;
        Amount = amount;
        TransactionDate = transactionDate;
        TransactionStatus = transactionStatus;
        Notes = notes;
        CreatedByUserID = createdByUserID;
        TransferID = transferID;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
