import React from 'react';
import ReactDOM from 'react-dom/client';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import ThemeJss from './theme';

const SiteRouteLazy = React.lazy(() => import('./app/route'))

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);
root.render(
    <ThemeJss>
        <BrowserRouter>
            <Routes>
                <Route path='/app/*' element={<SiteRouteLazy />} />
                <Route path='*' element={<SiteRouteLazy />} />
            </Routes>
        </BrowserRouter>
    </ThemeJss>
);

reportWebVitals();
