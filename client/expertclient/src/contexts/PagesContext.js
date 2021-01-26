import React, { createContext, useState } from 'react';
import {ADMIN, DOCTOR, PATIENT} from "../utils/Roles"

import { FiHome } from 'react-icons/fi';
import { MdHealing } from 'react-icons/md';
import { AiFillSetting } from 'react-icons/ai';
import { FiUsers } from 'react-icons/fi';

export const PagesContext = createContext();

const PagesContextProvider = ({ children }) => {
    // eslint-disable-next-line
    const [pages, setPages] = useState([
        {label: 'Strona główna', url: '/', role: false , icon: FiHome},
        {label: 'Diagnoza', url: '/diagnosis', role: DOCTOR , icon: MdHealing},
        {label: 'Zestaw treningowy', url: '/training', role: DOCTOR , icon: AiFillSetting},
        {label: 'Użytkownicy', url: '/Users', role: ADMIN , icon: FiUsers},
    ]);

    return (
        <PagesContext.Provider value={{pages}}>
            {children}
        </PagesContext.Provider>
    )
}

export default PagesContextProvider;