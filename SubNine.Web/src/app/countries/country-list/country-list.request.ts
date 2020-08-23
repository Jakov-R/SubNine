import { Country } from '../country';

export interface CountryListRequest {
    success: boolean;
    response: Country[];
}