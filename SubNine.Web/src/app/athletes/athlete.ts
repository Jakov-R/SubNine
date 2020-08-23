import { Club } from '../clubs/club';
import { Country } from '../countries/country';

export interface Athlete {
    id: number;
    fullName: string,
    yearsOld: number,
    club: Club,
    clubId: number,
    country: Country,
    countryId: number
}
