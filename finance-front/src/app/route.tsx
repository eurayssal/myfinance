import React from 'react';
import { Navigate, Route, Routes } from 'react-router-dom';
import ThemeJss from '../theme';
import HomeView from './home';

const SiteRoute: React.FC = () => {
    return (
        <ThemeJss>
            <Routes>
                <Route index element={<Navigate to='home' />} />
                <Route path='home' element={<HomeView/>}/>
               
            </Routes>
        </ThemeJss>
    );
};

export default SiteRoute;
