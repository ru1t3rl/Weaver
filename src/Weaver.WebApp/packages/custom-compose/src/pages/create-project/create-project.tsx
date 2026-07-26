import { Backdrop } from '@weaver/app/src/components/modals/backdrop/backdrop';
import { Button, Card, Divider, Input, Typography } from 'antd';
import styles from './create-project.module.scss';
import { LuSave } from 'react-icons/lu';
import { useComposeProjects } from '../../hooks/use-compose-projects';
import { useState } from 'react';
import { useNavigate } from 'react-router';
import { routes } from '@weaver/shared';

export const CreateProject = () => {
    const { create } = useComposeProjects();
    const navigate = useNavigate();

    const [name, setName] = useState<string>('');
    const [description, setDescription] = useState<string | undefined>(undefined);

    function handleCancelClick() {
        history.back();
    }

    async function handleSaveClick() {
        const id = await create(name, description, []);

        if (id) {
            navigate(routes.project(id));
        }
    }

    return (
        <Backdrop>
            <Card className={styles['container']}>
                <Typography.Title level={2}>Create a project</Typography.Title>
                <Divider size='medium' />
                <div className={styles['inputs']}>
                    <div>
                        <Typography.Title level={5}>Name</Typography.Title>
                        <Input title='Name' placeholder='A sepcial compose' required value={name} onChange={(e) => setName(e.currentTarget.value)} />
                    </div>
                    <div>
                        <Typography.Title level={5}>Description</Typography.Title>
                        <Input.TextArea title='Description' placeholder='Something to explain your compose' rows={4} value={description} onChange={(e) => setDescription(e.currentTarget.value)} />
                    </div>
                </div>

                <div className={styles['button-container']}>
                    <Button onClick={handleSaveClick} icon={<LuSave />} variant='filled'>Save</Button>
                    <Button onClick={handleCancelClick} variant='text'>Cancle</Button>
                </div>
            </Card>
        </Backdrop>
    )
}