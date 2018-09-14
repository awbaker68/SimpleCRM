import { InMemoryDbService } from 'angular-in-memory-web-api';

export class InMemoryDataService implements InMemoryDbService {
	createDb() {
		const customers = [
			{ id: 11, firstname: 'John', surname: 'Smith', address: ' 1 Main street', phone: '555-123', email: 'johnsmith@somwdomain.com' },
			{ id: 12, firstname: 'Hannah', surname: 'Ford', address: '2 Main street', phone: '555-124', email: 'hannahford@somwdomain.com' },
			{ id: 13, firstname: 'Dave', surname: 'Jones', address: '3 Main street', phone: '555-125', email: 'davejones@somwdomain.com' },
			{ id: 14, firstname: 'Sophie', surname: 'Hughes', address: '4 Main street', phone: '555-126', email: 'sophiehughes@somwdomain.com' },
			{ id: 15, firstname: 'Sally', surname: 'Jones', address: '5 Main street', phone: '555-127', email: 'sallyjones@somwdomain.com' },
			{ id: 16, firstname: 'Tony', surname: 'Smith', address: '6 Main street', phone: '555-128', email: 'tonysmith@somwdomain.com' },
			{ id: 17, firstname: 'Tracy', surname: 'Fisher', address: '7 Main street', phone: '555-129', email: 'tracyfisher@somwdomain.com' },
			{ id: 18, firstname: 'Darren', surname: 'Davis', address: '8 Main street', phone: '555-130', email: 'darrendavis@somwdomain.com' },
			{ id: 19, firstname: 'Mia', surname: 'Hughes', address: '9 Main street', phone: '555-131', email: 'miahughes@somwdomain.com' },
			{ id: 20, firstname: 'Ella', surname: 'Williams', address: '10 Main street', phone: '555-132', email: 'ellawilliams@somwdomain.com' }
		];
		return { customers };
	}
}