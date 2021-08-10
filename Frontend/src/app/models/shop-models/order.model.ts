import { OrdersProducts } from './orders-products.model';
import { Customer } from './customer.model';
import { Carrier } from './carrier.model';
import { Status } from './status.model';
import { PaymentType } from './payment-type.model';

export interface Order{
    id: number;
    paymentTypeId: number;
    paymentType: PaymentType;
    statusId: number;
    status: Status;
    carrierId: number;
    carrier: Carrier;
    customerId: number;
    customer: Customer;
    totalPrice: number;
    date: Date;
    additionalDescription: string;
    ordersProducts: OrdersProducts[];

    deliveryAddressStreet: string;
    deliveryAddressPostal: string;
    deliveryAddressCity: string;
    deliveryAddressCountry: string;

    billingAddressStreet: string;
    billingAddressPostal: string;
    billingAddressCity: string;
    billingAddressCountry: string;

    nip: string;
    companyName: string;
    customerPhoneNumber: string;
    customerEmail: string;
}