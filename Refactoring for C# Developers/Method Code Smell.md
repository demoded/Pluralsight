###Long Method
*Method should fit on one screen*
*Ideally fewer than 10 lines of code*
*Replace Nested Conditional with Guard Clauses*
```
public void BadMethod(Customer customer, Order order Logger logger)
{
	if(customer != null)
	{
		if (order != null)
		{
			if(logger != null)
			{
				//do actual work
			}
			else
			{
				throw new ArgumentNullException("Logger cannot be null");
			}
		}
		else
		{
			throw new ArgumentNullException("Order cannot be null");
		}
	}
	else
	{
		throw new ArgumentNullException("Customer cannot be null");
	}
}

public void GoodMethod(Customer customer, Order order Logger logger)
{
	if(customer == null)
	{
		throw new ArgumentNullException("Customer cannot be null");
	}

	if (order == null)
	{
		throw new ArgumentNullException("Order cannot be null");
	}

	if(logger == null)
	{
		throw new ArgumentNullException("Logger cannot be null");
	}

	//do actual work
}
```
*Replace Conditional Dispatcher with Command*
*Move Accumulation to Visitor*
*Replace Conditional Logic with Strategy*
```
//too cryptic
public int m_otCalc()
{
	return iThsWkd * iThsRte + (int)Math.Round(0.5 * iThsRte * Math.Max(0, iThsWkd - 400));
}
//replace with this
public int CalculateStraightPay()
{
	return tenthsWorked * tenthsRate;
}
public int CalculateOverTimePay()
{
	int overTimeTenths = Math.Max(0, tenthsWorked - 400);
	int overTimePay = CalculateOverTimeBonus(overTimeTenths);
	return CalculateStraightPay() + overTimePay;
}
public int CalculateOverTimeBonus(int overTimeTenths)
{
	double bonus = 0.5 * tenthsRate * overTimeTenths;
	return (int)Math.Round(bonus);
}
```
###Conditional Complexity
*Methods should limit the amount of conditional complexity they contain. The number of unique logical paths through a method*
*can be a measuerd as __Cyclomatic Complexity__, which should be kept under 10*
Bad example[https://github.com/NotMyself/GildedRose/blob/master/src/GildedRose.Console/Program.cs]

###Inconsistent Abstraction Level
*Methods should operate at a consistent abstraction level.*
*Don't mix high level and low level behaviour in the same method.*
If method needs to perform a buisiness logic or database access it should call other methods to do so.

###Separate Query from Modifier
*Methods that return values and modifies system state should be separated to individual methods.*
```
public void ProcessAccounts(IEnumerable<Account> accounts)
{
	foreach(var account in accounts)
	{
		var overdueInvoices = account.ProcessOverdueInvoices(DateTime.Now);
		UpdateReport(overdueInvoices);
	}
}
public IEnumerable<Invoice> ProcessOverdueInvoices (DateTime processDate)
{
	foreach (var invoice in Invoices.Where(i => (!i.Paid && i.PaymentDueDate < processDate)))
	{
		if (Status != AccountStatus.Overdue)
		{
			UpdateStatus(AccountStatus.Overdue);
		}
		SendPastDueNotice(invoice);
	}
	return Invoices.Where(i => (!i.Paid && i.PaymentDueDate < processDate));
}

//refactored
public void ProcessAccounts(IEnumerable<Account> accounts)
{
	foreach(var account in accounts)
	{
		DateTime processDate = DateTime.Now;
		account.ProcessOverdueInvoices(processDate)
		
		var overdueInvoices = account.ListPastDueInvoices(processDate);
		UpdateReport(overdueInvoices);
	}
}
public IEnumerable<Invoice> ListPastDueInvoices(DateTime processDate)
{
	return Invoices.Where(i => (!i.Paid && i.PaymentDueDate < processDate));
}
public void ProcessOverdueInvoices (DateTime processDate)
{
	foreach (var invoice in ListPastDueInvoices(processDate))
	{
		if (Status != AccountStatus.Overdue)
		{
			UpdateStatus(AccountStatus.Overdue);
		}
		SendPastDueNotice(invoice);
	}
}

```