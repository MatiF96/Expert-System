import React, { createContext, useState } from 'react';
import {ADMIN, DOCTOR, PATIENT} from "../utils/Roles"

export const PagesContext = createContext();

const PagesContextProvider = ({ children }) => {
    // eslint-disable-next-line
    const [pages, setPages] = useState([
        {label: 'Strona główna', url: '/', role: false},
        {label: 'Diagnoza', url: '/diagnosis', role: DOCTOR},
        {label: 'Zestaw treningowy', url: '/training', role: DOCTOR},
        {label: 'Użytkownicy', url: '/Users', role: ADMIN},
    ]);

    return (
        <PagesContext.Provider value={{pages}}>
            {children}
        </PagesContext.Provider>
    )
}

export default PagesContextProvider;