import { Component, OnInit } from '@angular/core';
import { Customer } from '../customer';
import { CustomerService } from '../customer.service';

@Component({
	selector: 'app-customers',
	templateUrl: './customers.component.html',
	styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

	customers: Customer[]

	constructor(private customerService: CustomerService) { }

	ngOnInit() {
		this.getCustomers();
	}

	getCustomers(): void {
		this.customerService.getCustomers()
			.subscribe(customers => this.customers = customers);
	}

	add(firstname: string, surname: string): void {
		firstname = firstname.trim();
		surname = surname.trim();
		if (!firstname || !surname) { return; }

		this.customerService.addCustomer({ firstname, surname } as Customer)
			.subscribe(customer => {
				this.customers.push(customer);
			});
	}

	delete(customer: Customer): void {
		this.customers = this.customers.filter(c => c !== customer);
		this.customerService.deleteCustomer(customer).subscribe();
	}
}
