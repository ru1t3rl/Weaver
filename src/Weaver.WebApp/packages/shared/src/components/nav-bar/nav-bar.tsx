import { Button, Card, Divider } from "antd";
import { LuHouse, LuLogOut, LuPlus } from 'react-icons/lu';
import styles from './nav-bar.module.scss';
import { ThemeToggle, useTheme } from "@weaver/styling";
import WeaverLogo from "../../weaver-logo";
import { useNavigate } from "react-router";
import { routes } from "../../routes";
import { useDevice } from "../../hooks/use-device";

export const NavBar = () => {
    const theme = useTheme();
    const navigate = useNavigate();
    const { isMobile } = useDevice();

    function handleHomeClicked() {
        navigate(routes.home);
    }

    function handleNewProjectClicked() {
        navigate(routes.newProject);
    }

    return (
        <Card className={styles['nav-bar-container']}>
            <div className={styles['nav-bar-top']}>
                <WeaverLogo className={styles['logo']} onClick={handleHomeClicked} color={theme.theme.token?.colorTextBase} />
                {!isMobile && <Button icon={<LuHouse />} onClick={handleHomeClicked} className={styles['icon-button']} />}
                <Divider size={'small'} />
                <Button icon={<LuPlus />} className={styles['icon-button']} onClick={handleNewProjectClicked}/>
            </div>
            <div className={styles['nav-bar-bottom']}>
                <ThemeToggle />
                {!isMobile && <Button icon={<LuLogOut />} className={styles['icon-button']} />}
            </div>
        </Card>
    );
}