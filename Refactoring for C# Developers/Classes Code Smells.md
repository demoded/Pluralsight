###Large class

###Class doesn't do much

###Replace Inheritance with Delegation
1. Create and initialize a field in the subclass with the type of the superclass
2. Change each method defined in the subclass to use this new field
3. Compile and run tests
4. Remove the subclass declaration
5. For each superclass method a client class uses, add a delegating method
6. Compile and run tests
```
public class Coompany : List<Employee>
{
	public IEnumerable<Employee> ListCurrentEmployees
	{
		return this.Where(e => e.IsEmployed).AsEnumerable();
	}
	public void Hire (Employee employee)
	{
		this.Add(employee);
	}
	public void Fire (Employee employee)
	{
		this.Remove(employee);
	}
}
public class ClientCode
{
	public void Main()
	{
		var company = new Company();
		var employees = company.ListCurrentEmployees();
		var employee = new Employee();
		
		// ok 
		company.Hire (employee);

		// ok 
		company.Fire (employee);
		
		// should not be allowed 
		company.clear();
	}
}

//refactored
public class Coompany
{
	private List<Employee> _emploees = new List<Emploee>();

	public IEnumerable<Employee> ListCurrentEmployees
	{
		return _emploees.Where(e => e.IsEmployed).AsEnumerable();
	}
	public void Hire (Employee employee)
	{
		_emploees.Add(employee);
	}
	public void Fire (Employee employee)
	{
		_emploees.Remove(employee);
	}
	internal void Clead()
	{
		_emploees.Clear();
	}
}
public class ClientCode
{
	public void Main()
	{
		var company = new Company();
		var employees = company.ListCurrentEmployees();
		var employee = new Employee();
		
		// ok 
		company.Hire (employee);

		// ok 
		company.Fire (employee);
		
		// ok now
		company.Clear();
	}
}
```

###Replace Conditional with Polymorphism
