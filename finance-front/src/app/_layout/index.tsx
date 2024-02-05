import React, { PropsWithChildren } from "react";
import * as jss from "./jss";
import Logo from "../assets/logo.svg"
import { useNavigate } from "react-router-dom";

const AppLayout: React.FC<PropsWithChildren> = ({
    children,
}) => {
    const navigate = useNavigate();
    const toHome = () => navigate('/home')

    return (
        <jss.SiteLayout>

            <jss.TopBar>
                <jss.rigthConteiner>
                    <jss.LogoImg onClick={toHome} src={Logo} />
                </jss.rigthConteiner>
                <jss.LeftConteiner>
                    
                </jss.LeftConteiner>
            </jss.TopBar>

            <jss.LayoutContainerJss>
                {children}
            </jss.LayoutContainerJss>

            <jss.Footer>© Finance Club</jss.Footer>
        </jss.SiteLayout>
    )
}

export default AppLayout;
