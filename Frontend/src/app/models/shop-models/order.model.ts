import { OrdersProducts } from './orders-products.model';
import { Customer } from './customer.model';
import { Carrier } from './carrier.model';
import { Status } from './status.model';
import { PaymentType } from './payment-type.model';

export interface Order {
    id: number;
    paymentTypeId: number;
    paymentType?: PaymentType | null;
    statusId: number;
    status?: Status | null;
    carrierId: number;
    carrier?: Carrier | null;
    customerId: number;
    customer?: Customer | null;
    totalPrice: number;
    date: Date;
    additionalDescription: string;
    ordersProducts?: OrdersProducts[] | null;
    isActive: boolean;
    completeDate: Date;

    deliveryAddressStreet: string;
    deliveryAddressPostal: string;
    deliveryAddressCity: string;
    deliveryAddressCountry: string;

    billingAddressStreet?: string | null;
    billingAddressPostal?: string | null;
    billingAddressCity?: string | null;
    billingAddressCountry?: string | null;

    nip?: string | null;
    companyName?: string | null;
    customerPhoneNumber?: string | null;
    customerEmail?: string | null;
}