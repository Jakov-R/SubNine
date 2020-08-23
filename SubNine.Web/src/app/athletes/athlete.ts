import { Club } from '../clubs/club';

export interface Athlete {
    id: number;
    fullName: string,
    yearsOld: number,
    club: Club,
    clubId: number
    //country: Country,
    //countryId: number
}
