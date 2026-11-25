namespace LebanonPos.Domain;

public enum Currency { USD = 1, LBP = 2 }

public enum UserRole { Cashier = 1, Manager = 2, Owner = 3 }

/// <summary>How VAT applies to a product (Lebanese VAT law: standard rate, exempt basics, zero-rated exports).</summary>
public enum TaxCategory { Standard = 1, Exempt = 2, ZeroRated = 3 }

public enum PaymentMethod { Cash = 1, Card = 2 }

public enum SaleStatus { Completed = 1, Voided = 2 }
