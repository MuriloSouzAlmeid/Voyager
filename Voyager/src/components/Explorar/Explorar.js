import { ActivityIndicator, FlatList, ScrollView } from "react-native"
import { CardExplorar } from "../CardExplorar/CardExplorar"
import { SearchBar } from "../Search/style"
import { ContainerExplorar, ContainerList, LoadingContent } from "./style"
import { Grid } from "react-native-easy-grid"
import api from "../../service/Service";
import { TitleDefault } from "../Text/style"
import { useState } from "react"


export const Explorar = () => {
    const [searchText, setSearchText] = useState("")
    const [showLoading, setShowLoading] = useState(false)
    const [placesList, setPlacesList] = useState([])

    const HandleSearch = (place) => {
        setShowLoading(true)
        setPlacesList([])
        api.post(`/PlaceSearch?local=${place}`).then(response => {
            setPlacesList(response.data)
        }).catch(erro => {
            alert(erro)
        })
        setShowLoading(false)
    }

    return (
        <ContainerExplorar>
            <SearchBar placeholder={`Explorar...`} value={searchText} onChangeText={text => setSearchText(text)} onBlur={() => {
                setShowLoading(true)
                HandleSearch(searchText)
            }} />
            {showLoading === true ? (
                <LoadingContent>
                    <TitleDefault>
                        Buscando!
                    </TitleDefault>
                    <ActivityIndicator />
                </LoadingContent>
            ) : (placesList.length != 0 ? (
                <ContainerList>
                    <Grid style={{ padding: 15 }}>
                        <FlatList
                            horizontal={false}
                            data={placesList}
                            renderItem={({ item }) => <CardExplorar urlImage={item.imagem} title={item.nome} />}
                            numColumns={2}
                            showsVerticalScrollIndicator={false}
                        />
                    </Grid>
                </ContainerList>
            ) : (
                <LoadingContent>
                    <TitleDefault>
                        Informe um local!
                    </TitleDefault>
                </LoadingContent>
            ))}
        </ContainerExplorar>
    )
}